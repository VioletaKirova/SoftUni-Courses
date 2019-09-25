namespace SoftJail.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            var departments = new List<Department>();

            StringBuilder sb = new StringBuilder();

            foreach (var departmentDto in departmentDtos)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var areCellsValid = true;

                foreach (var cell in departmentDto.Cells)
                {
                    if (!IsValid(cell))
                    {
                        areCellsValid = false;
                        break;
                    }
                }

                if (!areCellsValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = departmentDto.Name
                };

                var cells = new List<Cell>();

                foreach (var cellDto in departmentDto.Cells)
                {
                    cells.Add(new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow,
                        Department = department
                    });
                }

                department.Cells = cells;

                departments.Add(department);

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonerDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            var prisoners = new List<Prisoner>();

            StringBuilder sb = new StringBuilder();

            foreach (var prisonerDto in prisonerDtos)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var areMailsValid = true;

                foreach (var mailDto in prisonerDto.Mails)
                {
                    if(!IsValid(mailDto))
                    {
                        areMailsValid = false;
                        break;
                    }
                }

                if (!areMailsValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = prisonerDto.ReleaseDate == null ? (DateTime?) null : DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };

                var mails = new List<Mail>();

                foreach (var mailDto in prisonerDto.Mails)
                {
                    mails.Add(new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address,
                        Prisoner = prisoner
                    });
                }

                prisoner.Mails = mails;

                prisoners.Add(prisoner);

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));

            var officerDtos = (ImportOfficerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var officers = new List<Officer>();

            StringBuilder sb = new StringBuilder();

            foreach (var officerDto in officerDtos)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isPositionValid = Enum.TryParse<Position>(officerDto.Position, out Position position);
                var isWeaponValid = Enum.TryParse<Weapon>(officerDto.Weapon, out Weapon weapon);

                if (!isPositionValid || !isWeaponValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //var arePrisonersValid = true;

                //var prisonerIds = context.Prisoners.Select(p => p.Id).ToArray();

                //foreach (var prisonerDto in officerDto.Prisoners)
                //{
                //    var prisonerDtoId = prisonerDto.Id;

                //    if (!prisonerIds.Contains(prisonerDtoId))
                //    {
                //        arePrisonersValid = false;
                //        break;
                //    }
                //}

                //if (!arePrisonersValid)
                //{
                //    sb.AppendLine("Invalid Data");
                //    continue;
                //}

                var officer = new Officer
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officerDto.DepartmentId
                };

                var officerPrisoners = new List<OfficerPrisoner>();

                foreach (var prisonerDto in officerDto.Prisoners)
                {
                    var prisonerId = prisonerDto.Id;

                    officerPrisoners.Add(new OfficerPrisoner
                    {
                        PrisonerId = prisonerId,
                        Officer = officer
                    });
                }

                officer.OfficerPrisoners = officerPrisoners;

                officers.Add(officer);

                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}