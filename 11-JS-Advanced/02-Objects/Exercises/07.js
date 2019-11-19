function solve(arr) {
  console.log(
    Array.from(new Set(arr.sort().sort((a, b) => a.length - b.length))).join(
      "\n"
    )
  );
}

solve([
  "Ashton",
  "Kutcher",
  "Ariel",
  "Lilly",
  "Keyden",
  "Aizen",
  "Billy",
  "Braston"
]);

solve([
  "Denise",
  "Ignatius",
  "Iris",
  "Isacc",
  "Indie",
  "Dean",
  "Donatello",
  "Enfuego",
  "Benjamin",
  "Biser",
  "Bounty",
  "Renard",
  "Rot"
]);
