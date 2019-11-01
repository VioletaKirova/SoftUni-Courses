function printDeckOfCards(cards) {
  const validFaces = [
    "2",
    "3",
    "4",
    "5",
    "6",
    "7",
    "8",
    "9",
    "10",
    "J",
    "Q",
    "K",
    "A"
  ];

  const validSuits = {
    S: "\u2660",
    H: "\u2665",
    D: "\u2666 ",
    C: "\u2663"
  };

  function createCard(face, suit) {
    class Card {
      _face;
      _suit;

      constructor(face, suit) {
        this.face = face;
        this.suit = suit;
      }

      get face() {
        return this._face;
      }

      set face(value) {
        if (validFaces.indexOf(value) === -1) {
          throw new Error("Ivalid card face!");
        }
        this._face = value;
      }

      get suit() {
        return this._suit;
      }

      set suit(value) {
        if (Object.keys(validSuits).indexOf(value) === -1) {
          throw new Error("Ivalid card suit!");
        }
        this._suit = value;
      }

      toString() {
        return `${this.face}${validSuits[this.suit]}`;
      }
    }

    return new Card(face, suit);
  }

  let formattedCards = Array(cards.length);

  try {
    for (let c of cards) {
      if (c.length < 2 || c.length > 3) {
        throw new Error(`Invalid card: ${c}`);
      }

      let currentCard = [...c];
      let suit = currentCard.pop();
      let face = currentCard.slice().join("");

      if (
        validFaces.indexOf(face) === -1 ||
        Object.keys(validSuits).indexOf(suit) === -1
      ) {
        throw new Error(`Invalid card: ${c}`);
      }

      formattedCards.push(createCard(face, suit));
    }
  } catch (ex) {
    console.log(ex.message);
    return;
  }

  console.log(
    formattedCards
      .map(x => x.toString())
      .join(" ")
      .trim()
  );
}

printDeckOfCards(["AS", "10D", "KH", "2C"]);
printDeckOfCards(["5S", "3D", "QD", "1C"]);
