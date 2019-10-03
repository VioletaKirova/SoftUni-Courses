function solve(data, criteria){
    function passesCriteria(key, value, element) {
        return element[key] === value;
    }

    function formatData(element, i) {
        return `${i}. ${element.first_name} ${element.last_name} - ${element.email}`;
    }

    let parsedData = JSON.parse(data);
    let params = criteria.split("-");

    let result = (
            criteria !== "all" ? 
            parsedData.filter(passesCriteria.bind(undefined, ...params)) : 
            parsedData)
        .map(formatData)
        .join("\n");

    return result;
}

console.log(
  solve(
  `[{
  "id": "1",
  "first_name": "Ardine",
  "last_name": "Bassam",
  "email": "abassam0@cnn.com",
  "gender": "Female"
}, {
  "id": "2",
  "first_name": "Kizzee",
  "last_name": "Jost",
  "email": "kjost1@forbes.com",
  "gender": "Female"
},  
{
  "id": "3",
  "first_name": "Evanne",
  "last_name": "Maldin",
  "email": "emaldin2@hostgator.com",
  "gender": "Male"
}]`, 
'gender-Female'
));