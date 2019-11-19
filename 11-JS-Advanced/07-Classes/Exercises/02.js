function solve(arr, critetia) {
  class Ticket {
    constructor(destination, price, status) {
      this.destination = destination;
      this.price = Number(price);
      this.status = status;
    }
  }

  let tickets = [...arr].reduce((acc, curr) => {
    let [destination, price, status] = curr.split("|").map(x => x.trim());
    acc.push(new Ticket(destination, price, status));
    return acc;
  }, []);

  return critetia === "price"
    ? [...tickets].sort((a, b) => a[critetia] - b[critetia])
    : [...tickets].sort((a, b) => a[critetia].localeCompare(b[critetia]));
}

console.log(
  solve(
    [
      "Philadelphia|94.20|available",
      "New York City|95.99|available",
      "  New York City|95.99|sold",
      "Boston|126.20|departed"
    ],
    "destination"
  )
);

console.log(
  solve(
    [
      "Philadelphia|94.20|available",
      "New York City|95.99|available",
      "New York City|95.99|sold",
      "Boston|126.20|departed"
    ],
    "status"
  )
);
