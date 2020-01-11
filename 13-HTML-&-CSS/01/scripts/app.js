const html = {
  nav: () => document.querySelector('nav'),
  headline: () => document.querySelector('#headline'),
  subHeadline: () => document.querySelector('#sub-headline'),
  hamburgerIcon: () => document.querySelector('.nav-hamburger-menu-icon'),
  dropDownMenu: () => document.querySelector('.nav-hamburger-menu-container')
}

const tl = new TimelineMax();

tl.fromTo(html.nav(), 1, { y: '-100%' }, { y: '0%', ease: Power2.easeInOut })
  .fromTo(html.headline(), 1.4, { opacity: 0 }, { opacity: 1 })
  .fromTo(
    html.headline(),
    1.2,
    { y: '100%' },
    { y: '-70%', ease: Power2.easeInOut },
    '-=1.4'
  )
  .fromTo(html.subHeadline(), 1.4, { opacity: 0 }, { opacity: 1 })
  .fromTo(html.subHeadline(), 1.2, {x: '-100%'}, {x: '0%', ease: Power2.easeInOut}, '-=1.4');

function showDropDownMenu() {
  html.dropDownMenu().style.display = "flex";

  html.hamburgerIcon().removeEventListener("click", showDropDownMenu);
  html.hamburgerIcon().addEventListener("click", hideDropDownMenu);
}

function hideDropDownMenu() {
  html.dropDownMenu().style.display = "none";

  html.hamburgerIcon().removeEventListener("click", hideDropDownMenu);
  html.hamburgerIcon().addEventListener("click", showDropDownMenu);
}

html.hamburgerIcon().addEventListener('click', showDropDownMenu);
html.dropDownMenu().addEventListener('click', hideDropDownMenu);