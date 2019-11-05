(function solve() {
  String.prototype.ensureStart = function(str) {
    if (!this.startsWith(str)) {
      return str + this;
    }
    return this.toString();
  };

  String.prototype.ensureEnd = function(str) {
    if (!this.endsWith(str)) {
      return this + str;
    }
    return this.toString();
  };

  String.prototype.isEmpty = function() {
    if (this.length === 0) {
      return true;
    }
    return false;
  };

  String.prototype.truncate = function(n) {
    if (n < 4) {
      return ".".repeat(n);
    }

    if (n >= this.length) {
      return this.toString();
    }

    const index = this.substr(0, n - 2).lastIndexOf(" ");
    if (index === -1) {
      return `${this.substr(0, n - 3)}...`;
    }
    return `${this.substr(0, index)}...`;
  };

  String.format = function(str) {
    let matches = str.match(/{\d}/g);

    for (i = 1; i < arguments.length; i++) {
      str = str.replace(matches[i - 1], arguments[i]);
    }

    return str;
  };
})();
