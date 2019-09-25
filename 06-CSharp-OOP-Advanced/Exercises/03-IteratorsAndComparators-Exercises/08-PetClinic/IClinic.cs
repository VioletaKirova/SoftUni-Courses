namespace _08_PetClinic
{
    public interface IClinic
    {
        string Name { get; }

        Pet[] Rooms { get; }

        bool AddPet(Pet pet);

        bool Release();

        bool HasEmptyRooms();

        void PrintRoom(int roomNumber);

        void PrintAllRooms();
    }
}
