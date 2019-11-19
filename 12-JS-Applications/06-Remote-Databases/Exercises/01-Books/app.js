import { get, post, put, del } from "./requester.js";

function createElement(tag, content) {
  const element = document.createElement(tag);

  if (content) {
    element.textContent = content;
  }

  return element;
}

function isInputValid(title, author, isbn) {
  return (
    title !== null &&
    author !== null &&
    isbn !== null &&
    title.value !== "" &&
    author.value !== "" &&
    isbn.value !== ""
  );
}

const actions = {
  "load-books": async function() {
    let books;

    try {
      books = await get("appdata", "books");
    } catch (err) {
      console.log(err.message);
    }

    html.allBooks().innerHTML = "";

    books.forEach(b => {
      const tr = createElement("tr");

      const titleTd = createElement("td", b.title);
      const authorTd = createElement("td", b.author);
      const isbnTd = createElement("td", b.isbn);

      const btnWrapperTd = createElement("td");
      const editBtn = createElement("button", "Edit");
      const deleteBtn = createElement("button", "Delete");

      editBtn.setAttribute("data-target", b._id);
      deleteBtn.setAttribute("data-target", b._id);

      editBtn.addEventListener("click", this["edit-book-get"]);
      deleteBtn.addEventListener("click", this["delete-book"]);

      btnWrapperTd.append(editBtn, deleteBtn);
      tr.append(titleTd, authorTd, isbnTd, btnWrapperTd);

      html.allBooks().appendChild(tr);
    });
  },
  "create-book": async function() {
    const title = html.createTitle();
    const author = html.createAuthor();
    const isbn = html.createISBN();

    if (isInputValid(title, author, isbn)) {
      const data = {
        title: title.value,
        author: author.value,
        isbn: isbn.value
      };

      await post("appdata", "books", data);
    }

    title.value = "";
    author.value = "";
    isbn.value = "";

    this["load-books"]();
  },
  "edit-book-get": async function() {
    const bookId = this.getAttribute("data-target");

    let book;

    try {
      book = await get("appdata", `books/${bookId}`);
      console.log(book);
    } catch (err) {
      console.log(err.message);
    }

    html.editId().value = bookId;
    html.editTitle().value = book.title;
    html.editAuthor().value = book.author;
    html.editISBN().value = book.isbn;
  },
  "edit-book-post": async function() {
    const id = html.editId().value;
    const title = html.editTitle();
    const author = html.editAuthor();
    const isbn = html.editISBN();

    if (isInputValid(title, author, isbn)) {
      const data = {
        title: title.value,
        author: author.value,
        isbn: isbn.value
      };

      await put("appdata", `books/${id}`, data);
    }

    title.value = "";
    author.value = "";
    isbn.value = "";

    this["load-books"]();
  },
  "delete-book": async function() {
    const bookId = this.getAttribute("data-target");

    if (confirm("Are you sure you want to delete this book?")) {
      try {
        await del("appdata", `books/${bookId}`);
      } catch (err) {
        console.log(err.message);
      }
    }

    actions["load-books"]();
  }
};

const html = {
  createTitle: () => document.getElementById("create-title"),
  createAuthor: () => document.getElementById("create-author"),
  createISBN: () => document.getElementById("create-isbn"),
  editId: () => document.getElementById("edit-id"),
  editTitle: () => document.getElementById("edit-title"),
  editAuthor: () => document.getElementById("edit-author"),
  editISBN: () => document.getElementById("edit-isbn"),
  allBooks: () => document.getElementById("all-books")
};

function handleEvent(evt) {
  evt.preventDefault();

  if (actions[evt.target.id] !== undefined) {
    actions[evt.target.id](evt);
  }
}

document.addEventListener("click", handleEvent);
