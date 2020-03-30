<template>
  <div id="cards">
    <div class="counter">
      <h1>{{ timer }}</h1>
    </div>
    <section class="memory-game">
      <div
        v-for="(card, index) in cards"
        :key="index"
        class="memory-card"
        :class="{ flip: card.isFlipped, 'disable-card': card.isMatched  }"
        :data-framework="card.framework"
        @click="cardClickHandler(card)"
      >
        <img class="front-face" :src="card.src" :alt="card.alt" />
        <img class="back-face" src="../assets/img/js-badge.svg" alt="JS Badge" />
      </div>
    </section>
  </div>
</template>

<script>
import aurelia from "../assets/img/aurelia.svg";
import vue from "../assets/img/vue.svg";
import angular from "../assets/img/angular.svg";
import backbone from "../assets/img/backbone.svg";
import ember from "../assets/img/ember.svg";
import react from "../assets/img/react.svg";

export default {
  data: function() {
    return {
      timer: 60,
      matches: 0,
      hasWon: false,
      firstCard: null,
      secondCard: null,
      cards: [
        {
          framework: "aurelia",
          src: aurelia,
          alt: "Aurelia",
          isFlipped: false,
          isMatched: false
        },
        {
          framework: "aurelia",
          src: aurelia,
          alt: "Aurelia",
          isFlipped: false,
          isMatched: false
        },
        {
          framework: "vue",
          src: vue,
          alt: "Vue",
          isFlipped: false,
          isMatched: false
        },
        {
          framework: "vue",
          src: vue,
          alt: "Vue",
          isFlipped: false,
          isMatched: false
        },
        {
          framework: "angular",
          src: angular,
          alt: "Angular",
          isFlipped: false,
          isMatched: false
        },
        {
          framework: "angular",
          src: angular,
          alt: "Angular",
          isFlipped: false,
          isMatched: false
        },
        {
          framework: "ember",
          src: ember,
          alt: "Ember",
          isFlipped: false,
          isMatched: false
        },
        {
          framework: "ember",
          src: ember,
          alt: "Ember",
          isFlipped: false,
          isMatched: false
        },
        {
          framework: "backbone",
          src: backbone,
          alt: "Backbone",
          isFlipped: false,
          isMatched: false
        },
        {
          framework: "backbone",
          src: backbone,
          alt: "Backbone",
          isFlipped: false,
          isMatched: false
        },
        {
          framework: "react",
          src: react,
          alt: "React",
          isFlipped: false,
          isMatched: false
        },
        {
          framework: "react",
          src: react,
          alt: "React",
          isFlipped: false,
          isMatched: false
        }
      ]
    };
  },
  methods: {
    decrementTimer() {
      this.timer--;
    },
    startTimer() {
      setInterval(this.decrementTimer, 1000);
    },
    cardClickHandler(card) {
      if (!this.firstCard) {
        this.firstCard = card;
        this.firstCard.isFlipped = true;
      } else if (!this.secondCard) {
        this.secondCard = card;
        this.secondCard.isFlipped = true;

        if (this.firstCard.framework === this.secondCard.framework) {
          this.firstCard.isMatched = true;
          this.secondCard.isMatched = true;

          this.matches++;
        } else {
          this.firstCard.isFlipped = false;
          this.secondCard.isFlipped = false;
        }

        this.firstCard = null;
        this.secondCard = null;
      }
    },
    shuffle() {
      for (let i = this.cards.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [this.cards[i], this.cards[j]] = [this.cards[j], this.cards[i]];
      }
    },
    clear() {
      this.cards.map(c => {
        c.isFlipped = false;
        c.isMatched = false;
      });
    },
    startOver() {
      this.matches = 0;
      this.hasWon = false;
      this.timer = 60;

      this.clear();
      this.shuffle();
    },
    endGame() {
      if (this.hasWon) {
        if (confirm("Congrats! You won! Wanna play again?")) {
          this.startOver();
        }
      } else {
        if (confirm("Game Over! Wanna try again?")) {
          this.startOver();
        }
      }
    }
  },
  watch: {
    timer: function(newValue) {
      if (newValue === 0) {
        this.endGame();
      }
    },
    matches: function(newValue) {
      if (newValue === 6) {
        this.hasWon = true;
        this.endGame();
      }
    }
  },
  mounted() {
    this.shuffle();
    this.startTimer();
  }
};
</script>

<style scoped>
.memory-game {
  width: 640px;
  height: 640px;
  margin: auto;
  display: flex;
  flex-wrap: wrap;
  perspective: 1000px;
}

.memory-card {
  width: calc(25% - 10px);
  height: calc(33.333% - 10px);
  margin: 5px;
  position: relative;
  transform: scale(1);
  transform-style: preserve-3d;
  transition: transform 0.5s;
  box-shadow: 1px 1px 1px rgba(0, 0, 0, 0.3);
}

.disable-card {
  pointer-events: none;
}

.memory-card:active {
  transform: scale(0.97);
  transition: transform 0.2s;
}

.memory-card.flip {
  transform: rotateY(180deg);
}

.front-face,
.back-face {
  width: 100%;
  height: 100%;
  padding: 20px;
  position: absolute;
  border-radius: 5px;
  background: #fff29e;
  backface-visibility: hidden;
}

.front-face {
  transform: rotateY(180deg);
}

.counter {
  position: absolute;
  top: 10px;
  right: 10px;
}
</style>