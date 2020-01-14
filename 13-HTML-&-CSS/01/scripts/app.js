const html = {
  nav: () => document.getElementById('nav'),
  headline: () => document.getElementById('headline'),
  subHeadline: () => document.getElementById('sub-headline'),
  imgBack: () => document.getElementById('img-back'),
  imgFront: () => document.getElementById('img-front'),
  hamburgerIcon: () => document.getElementById('ham-icon'),
  dropDownMenu: () => document.getElementById('ham-menu')
};

const tl = new TimelineMax();

tl.fromTo(html.nav(), 1, { y: '-100%' }, { y: '0%', ease: Power2.easeInOut })
  .fromTo(
    html.imgBack(),
    1.8,
    { y: '-10%' },
    { y: '0%', ease: Power2.easeInOut }
  )
  .fromTo(
    html.imgFront(),
    1.8,
    { y: '-10%' },
    { y: '0%', ease: Power2.easeInOut },
    '-=1.8'
  )
  .fromTo(html.headline(), 1.8, { opacity: 0 }, { opacity: 1 }, '-=1.8')
  .fromTo(
    html.headline(),
    1.6,
    { y: '100%' },
    { y: '-70%', ease: Power2.easeInOut },
    '-=1.8'
  )
  .fromTo(html.subHeadline(), 1.8, { opacity: 0 }, { opacity: 1 }, '-=1.8')
  .fromTo(
    html.subHeadline(),
    1.8,
    { y: '550%' },
    { y: '0%', ease: Power2.easeInOut },
    '-=1.8'
  );

function showDropDownMenu() {
  html.dropDownMenu().style.display = 'flex';

  html.hamburgerIcon().removeEventListener('click', showDropDownMenu);
  html.hamburgerIcon().addEventListener('click', hideDropDownMenu);
}

function hideDropDownMenu() {
  html.dropDownMenu().style.display = 'none';

  html.hamburgerIcon().removeEventListener('click', hideDropDownMenu);
  html.hamburgerIcon().addEventListener('click', showDropDownMenu);
}

html.hamburgerIcon().addEventListener('click', showDropDownMenu);
html.dropDownMenu().addEventListener('click', hideDropDownMenu);
