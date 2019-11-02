class Forum {
  #users;
  #questions;
  #id;

  constructor() {
    this._users = [];
    this._questions = [];
    this._id = 1;
  }

  get _questions(){
    return this.#questions;
  }

  set _questions(arr){
    this.#questions = arr;
  }

  get _users(){
    return this.#users;
  }

  set _users(arr){
    this.#users = arr;
  }

  get _id() {
    return this.#id;
  }

  set _id(number) {
    this.#id = number;
  }

  register(username, password, repeatPassword, email) {
    if (
      username === "" ||
      password === "" ||
      repeatPassword === "" ||
      email === ""
    ) {
      throw new Error("Input can not be empty");
    }

    if (password !== repeatPassword) {
      throw new Error("Passwords do not match");
    }

    if (
      this._users.findIndex(
        x => x.username === username || x.email === email
      ) !== -1
    ) {
      throw new Error("This user already exists!");
    }

    let user = {
      username,
      password,
      email,
      logged: false
    };

    this._users.push(user);
    return `${username} with ${email} was registered successfully!`;
  }

  login(username, password) {
    if (this._users.findIndex(x => x.username === username) === -1) {
      throw new Error("There is no such user");
    }

    let user = this._users.find(
      x => x.username === username && x.password === password
    );

    if (user !== undefined) {
      user.logged = true;
      return "Hello! You have logged in successfully";
    }
  }

  logout(username, password) {
    if (this._users.findIndex(x => x.username === username) === -1) {
      throw new Error("There is no such user");
    }

    let user = this._users.find(
      x => x.username === username && x.password === password
    );

    if (user !== undefined) {
      user.logged = false;
      return "You have logged out successfully";
    }
  }

  postQuestion(username, question) {
    let user = this._users.find(x => x.username === username);

    if (user === undefined || user.logged === false) {
      throw new Error("You should be logged in to post questions");
    }

    if (question === "") {
      throw new Error("Invalid question");
    }

    this._questions.push({
      id: this._id,
      username: username,
      question: question,
      answers: []
    });
    
    this._id += 1;

    return "Your question has been posted successfully";
  }

  postAnswer(username, questionId, answer) {
    let user = this._users.find(x => x.username === username);

    if (user === undefined || user.logged === false) {
      throw new Error("You should be logged in to post answers");
    }

    if (answer === "") {
      throw new Error("Invalid answer");
    }

    let question = this._questions.find(x => x.id === Number(questionId));

    if (question === undefined) {
      throw new Error("There is no such question");
    }

    question.answers.push({
      username,
      answer
    });

    return "Your answer has been posted successfully";
  }

  showQuestions() {
    let result = "";

    for(let q of this._questions){
      result += `Question ${q.id} by ${q.username}: ${q.question}\n`
      for(let a of q.answers){
        result += `---${a.username}: ${a.answer}\n`
      }
    }

    return result.trim();
  }
}

let forum = new Forum();

forum.register('Jonny', '12345', '12345', 'jonny@abv.bg');
forum.register('Peter', '123ab7', '123ab7', 'peter@gmail@.com');
forum.login('Jonny', '12345');
forum.login('Peter', '123ab7');

forum.postQuestion('Jonny', "Do I need glasses for skiing?");
forum.postAnswer('Peter',1, "Yes, I have rented one last year.");
forum.postAnswer('Jonny',1, "What was your budget");
forum.postAnswer('Peter',1, "$50");
forum.postAnswer('Jonny',1, "Thank you :)");

console.log(forum.showQuestions());

