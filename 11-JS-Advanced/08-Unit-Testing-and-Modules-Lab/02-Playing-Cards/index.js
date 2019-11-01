function createCard(face, suit) {
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
