function solve(currencyFormatter){
    return (value) => currencyFormatter(",", "$", true, value);
}