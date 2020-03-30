<template>
  <div class="container">
    <form @submit.prevent="submitHandler">
      <fieldset>
        <h1>Registration Form</h1>

        <p class="field field-icon">
          <label for="username">
            <span>
              <i class="fas fa-user"></i>
            </span>
          </label>
          <input type="text" name="username" id="username" :class="{ error: $v.username.$error }" placeholder="Mark Ulrich" v-model="username" @blur="$v.username.$touch" />
        </p>

        <template v-if="$v.username.$error">
          <p v-if="!$v.username.required" class="error">Username is required!</p>
          <p v-else-if="!$v.username.usernameValidation" class="error">Username must contain first name and last name with capital letters!</p>
        </template>

        <p class="field field-icon">
          <label for="email">
            <span>
              <i class="fas fa-envelope"></i>
            </span>
          </label>
          <input type="text" name="email" id="email" :class="{ error: $v.email.$error }" placeholder="marg@gmial.com" v-model="email" @blur="$v.email.$touch" />
        </p>

        <template v-if="$v.email.$error">
          <p v-if="!$v.email.required" class="error">Email is required!</p>
          <p v-else-if="!$v.email.email" class="error">Email is invalid!</p>
        </template>

        <p class="field field-icon">
          <label for="tel">
            <span>
              <i class="fas fa-phone"></i>
            </span>
          </label>
          <select name="tel-code" id="tel-code" class="tel">
            <option value="1">+359</option>
          </select>
          <input type="text" name="tel" id="tel" :class="{ error: $v.tel.$error }" placeholder="888 888" v-model="tel" @blur="$v.tel.$touch" />
        </p>

        <template v-if="$v.tel.$error">
          <p v-if="!$v.tel.required" class="error">Telephone is required!</p>
          <p v-else-if="!$v.tel.numeric" class="error">Telephone must contain only digits!</p>
          <p v-else-if="!$v.tel.minLenght || !$v.tel.maxLenght" class="error">Telephone must be exactly 9 digits!</p>
        </template>

        <p class="field field-icon">
          <label for="profession">
            <span>
              <i class="fas fa-building"></i>
            </span>
          </label>
          <select name="profession" id="profession" class="profession" :class="{ error: $v.profession.$error }" v-model="profession" @blur="$v.profession.$touch">
            <option :value="null">Select ...</option>
            <option value="1">Designer</option>
            <option value="2">Software Engineer</option>
            <option value="3">Accountant</option>
            <option value="4">Manager</option>
            <option value="5">Other</option>
          </select>
        </p>

        <template v-if="$v.profession.$error">
          <p v-if="!$v.profession.required" class="error">Profession is required!</p>
        </template>

        <p class="field field-icon">
          <label for="password">
            <span>
              <i class="fas fa-lock"></i>
            </span>
          </label>
          <input type="password" name="password" id="password" :class="{ error: $v.password.$error }" placeholder="******" v-model="password" @blur="$v.password.$touch" />
        </p>

        <template v-if="$v.password.$error">
          <p v-if="!$v.password.required" class="error">Password is required!</p>
          <p v-else-if="!$v.password.minLength" class="error">Password must be at least 3 characters long!</p>
          <p v-else-if="!$v.password.maxLength" class="error">Password must be at most 16 characters long!</p>
          <p v-else-if="!$v.password.alphanumeric" class="error">Password must contain only letters and digits!</p>
        </template>

        <p class="field field-icon">
          <label for="re-password">
            <span>
              <i class="fas fa-lock"></i>
            </span>
          </label>
          <input type="password" name="re-password" id="re-password" :class="{ error: $v.rePassword.$error }" placeholder="******" v-model="rePassword" @blur="$v.rePassword.$touch" />
        </p>

        <template v-if="$v.rePassword.$error">
          <p v-if="!$v.rePassword.sameAs" class="error">Repeat password does not match!</p>
        </template>

        <p>
          <button>Create Account</button>
        </p>

        <p class="text-center">
          Have an account?
          <a href>Log In</a>
        </p>
      </fieldset>
    </form>
  </div>
</template>

<script>
import { validationMixin  } from "vuelidate";
import { required, email, numeric, minLength, maxLength, sameAs, helpers } from "vuelidate/lib/validators";

const aplhanumeric = helpers.regex("aplhanumeric", /^[a-zA-Z0-9]*$/);
const usernameValidation = helpers.regex("usernameValidation", /^[A-Z]{1,1}[a-z]+[\s]{1,1}[A-Z]{1,1}[a-z]+$/);

export default {
  mixins: [ validationMixin ],
  data() {
    return {
      username: "",
      email: "",
      tel: "",
      profession: null,
      password: "",
      rePassword: ""
    };
  },
  validations: {
    username: {
      required,
      usernameValidation
    },
    email: {
      required,
      email
    },
    tel: {
      required,
      numeric,
      minLength: minLength(9),
      maxLength: maxLength(9),
    },
    profession: {
      required
    },
    password: {
      required,
      minLength: minLength(3),
      maxLength: maxLength(16),
      aplhanumeric
    },
    rePassword: {
      sameAsPassword: sameAs("password")
    }
  },
  methods: {
    submitHandler() {
      this.$v.$touch();
      if (this.$v.$error) {
        return;
      }
    }
  }
};
</script>

<style scoped>
form {
  margin-top: 20px;
  width: 40%;
}

fieldset {
  border-radius: 10px;
  padding: 20px;
}

input {
  flex: 0 1 100%;
  border: 1px solid;
  padding: 5px;
  border-left: 3px solid #42a948;
  border-top-right-radius: 3px;
  border-bottom-right-radius: 3px;
}

select {
  border-color: black;
}

button {
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 3px;
  padding: 0.8em 1.2em;
  width: 40%;
}

i {
  border: 1px solid;
  border-right: none;
  padding: 10px;
  border-top-left-radius: 3px;
  border-bottom-left-radius: 3px;
  background-color: #e9ecef;
}

a {
  color: #007bff;
}

.container {
  font-family: inherit;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  text-align: center;
}

.tel {
  padding-right: 20px;
}

.profession {
  flex: 1 1 100%;
  border-top-right-radius: 3px;
  border-bottom-right-radius: 3px;
}

form .field {
  display: flex;
}

p.error {
  text-align: left;
  background-color: #f8d7da;
  padding: 8px;
  border-radius: 3px;
}

input.error {
  border-left-color: #a8413f;
}
</style>