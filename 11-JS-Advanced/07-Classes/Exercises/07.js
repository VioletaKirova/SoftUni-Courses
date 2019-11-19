class CheckingAccount {
  _clietnId;
  _email;
  _firstName;
  _lastName;

  constructor(clientId, email, firstName, lastName) {
    this.clientId = clientId;
    this.email = email;
    this.firstName = firstName;
    this.lastName = lastName;
    this.products = [];
  }

  get clientId() {
    return this._clietnId;
  }

  set clientId(value) {
    if (value.match(/^\d{6,6}$/gi) === null) {
      throw TypeError("Client ID must be a 6-digit number");
    }

    this._clietnId = value;
  }

  get email() {
    return this._email;
  }

  set email(value) {
    if (value.match(/^\w+@[a-zA-Z.]+$/gi) === null) {
      throw new TypeError("Invalid e-mail");
    }

    this._email = value;
  }

  get firstName() {
    return this._firstName;
  }

  set firstName(value) {
    this.validateName(value, "First");

    this._firstName = value;
  }

  get lastName() {
    return this._lastName;
  }

  set lastName(value) {
    this.validateName(value, "Last");

    this._lastName = value;
  }

  validateName(value, type) {
    if (value.length < 3 || value.length > 20) {
      throw new TypeError(`${type} name must be between 3 and 20 characters long`);
    } else if (value.match(/^[a-zA-Z]+$/gi) === null) {
      throw new TypeError(`${type} name must contain only Latin characters`);
    }
  }
}
