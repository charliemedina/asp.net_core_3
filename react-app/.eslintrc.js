module.exports = {
    extends: [
      "airbnb",
      "react-app",
      "prettier",
      "prettier/react",
      "prettier/flowtype"
    ],
    plugins: ["react-hooks"],
    parser: "babel-eslint",
    env: {
      browser: true,
      node: true,
      jest: true,
      es6: true
    },
    rules: {
      indent: ["error", 2, { "SwitchCase": 1, "ignoredNodes": ["TemplateLiteral"] }],
      semi: ["error", "always"],
      camelcase: "warn",
      quotes: ["error", "double", { "avoidEscape": true }],
      "max-len": [
        "warn",
        {
          code: 100,
          tabWidth: 2,
          comments: 80,
          ignoreComments: true, // let's disable warnings on the comments
          ignoreTrailingComments: true,
          ignoreUrls: true,
          ignoreStrings: true,
          ignoreTemplateLiterals: true,
          ignoreRegExpLiterals: true
        }
      ],
    }
  };
  