function validateRequest(request) {
  function validateProperties() {
    let requestProperties = Object.keys(request);
    properties.forEach(x => {
      if (!requestProperties.includes(x)) {
        let formattedPropName =
          x === "uri"
            ? x.toUpperCase()
            : `${x[0].toUpperCase()}${[...x].slice(1).join("")}`;
        throw new Error(`Invalid request header: Invalid ${formattedPropName}`);
      }
    });
  }

  function validateMethod() {
    if (!methods.includes(request.method)) {
      throw new Error(`Invalid request header: Invalid Method`);
    }
  }

  function validateUri() {
    let uriPattern = new RegExp("^[A-Za-z0-9.]+$");
    if (
      (!uriPattern.test(request.uri) && request.uri !== "*") ||
      request.uri === ""
    ) {
      throw new Error(`Invalid request header: Invalid URI`);
    }
  }

  function validateVersion() {
    if (!versions.includes(request.version)) {
      throw new Error(`Invalid request header: Invalid Version`);
    }
  }

  function validateMessage() {
    let messagePattern = /[<>\\&'\"]+/gi;
    if (
      request.message.match(messagePattern) !== null &&
      request.message !== ""
    ) {
      throw new Error(`Invalid request header: Invalid Message`);
    }
  }

  const properties = ["method", "uri", "version", "message"];
  const methods = ["GET", "POST", "DELETE", "CONNECT"];
  const versions = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"];

  validateProperties();
  validateMethod();
  validateUri();
  validateVersion();
  validateMessage();

  return request;
}
