function symmetricNumbers(arr) {
    let n = Number(arr[0]);
    let output = '';
    for (let i = 1; i <= n; i++) {
        if(isSymmetric(i.toString())){
            output += i + ' ';
        }
    }
    console.log(output);
    function isSymmetric(str) {
        for (let i = 0; i < str.length / 2; i++) {
            if(str[i] != str[str.length - 1 - i]){
                return false;
            }
        }
        return true;
    }
}

symmetricNumbers(['1000']);
