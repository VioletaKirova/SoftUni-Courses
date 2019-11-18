function solve() {
  let text = "";
  return {
    append: str => (text += str),
    removeStart: n => (text = text.slice(n)),
    removeEnd: n => (text = text.slice(0, text.length - n)),
    print: () => console.log(text)
  };
}

let firstZeroTest = solve();

firstZeroTest.append("hello");
firstZeroTest.append("again");
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();
