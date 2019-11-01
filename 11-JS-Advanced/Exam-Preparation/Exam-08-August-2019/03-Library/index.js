class Library {
  constructor(libraryName) {
    this.libraryName = libraryName;
    this.subscribers = [];
    this.subscriptionTypes = {
      normal: libraryName.length,
      special: libraryName.length * 2,
      vip: Number.MAX_SAFE_INTEGER
    };
  }

  subscribe(name, type) {
    if (!this.subscriptionTypes.hasOwnProperty(type)) {
      throw new Error(`The type ${type} is invalid`);
    }

    let existingSubscriber = this.subscribers.find(x => x.name === name);

    if (existingSubscriber === undefined) {
      let newSubscriber = {
        name,
        type,
        books: []
      };

      this.subscribers.push(newSubscriber);

      return newSubscriber;
    }

    existingSubscriber.type = type;

    return existingSubscriber;
  }

  unsubscribe(name) {
    let subscriber = this.subscribers.find(x => x.name === name);

    if (subscriber === undefined) {
      throw new Error(`There is no such subscriber as ${name}`);
    }

    let subscriberIndex = this.subscribers.indexOf(subscriber);
    this.subscribers.splice(subscriberIndex, 1);

    return this.subscribers;
  }

  receiveBook(subscriberName, bookTitle, bookAuthor) {
    let subscriber = this.subscribers.find(x => x.name === subscriberName);

    if (subscriber === undefined) {
      throw new Error(`There is no such subscriber as ${subscriberName}`);
    }

    if (this.subscriptionTypes[subscriber.type] <= subscriber.books.length) {
      throw new Error(
        `You have reached your subscription limit ${
          this.subscriptionTypes[subscriber.type]
        }!`
      );
    }

    subscriber.books.push({
      title: bookTitle,
      author: bookAuthor
    });

    return subscriber;
  }

  showInfo() {
    if (this.subscribers.length === 0) {
      return `${this.libraryName} has no information about any subscribers`;
    }

    let result = "";

    this.subscribers.forEach(sub => {
      let subInfo = `Subscriber: ${sub.name}, Type: ${sub.type}\n`;
      let subBooks = sub.books
        .slice()
        .map(x => `${x.title} by ${x.author}`);

      let subBooksInfo = `Received books: ${subBooks.join(", ")}\n`;

      result += subInfo;
      result += subBooksInfo;
    });

    return result;
  }
}

let lib = new Library('Lib');

lib.subscribe('Peter', 'normal');
lib.subscribe('John', 'special');

lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
lib.receiveBook('Peter', 'Lord of the rings', 'J. R. R. Tolkien');
lib.receiveBook('John', 'Harry Potter', 'J. K. Rowling');

console.log(lib.showInfo());