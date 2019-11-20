function extractCapitalCaseWords(arr) {
    let inputArr = arr.join(",").split(/\W+/).filter(w => w != '').filter(isUpperCase);
    console.log(inputArr.join(", "));
    function isUpperCase(str) {
        return str === str.toUpperCase();
    }
}

extractCapitalCaseWords(['PHP, Java and HTML']);
