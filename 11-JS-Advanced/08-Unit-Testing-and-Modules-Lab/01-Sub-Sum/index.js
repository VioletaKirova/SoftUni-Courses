function subSum(arr, startIndex, endIndex) {
  if (!(arr instanceof Array)) {
    return NaN;
  }

  startIndex = startIndex < 0 ? 0 : startIndex;
  endIndex = endIndex >= arr.length ? arr.length - 1 : endIndex;

  return arr
    .slice(startIndex, endIndex + 1)
    .reduce((acc, curr) => acc + Number(curr), 0);
}
