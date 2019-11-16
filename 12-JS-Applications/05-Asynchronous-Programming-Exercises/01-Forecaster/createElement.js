export function createElement(tag, classes, content) {
  const element = document.createElement(tag);

  classes.forEach(x => {
    element.classList.add(x);
  });

  if (content) {
    element.innerHTML = content;
  }

  return element;
}