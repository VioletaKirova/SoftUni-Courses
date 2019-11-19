function solve() {
  return {
    call: (object, action) => {
      function calcVotePercentage(votes, all) {
        return (votes / all) * 100;
      }

      function upvote() {
        object.upvotes++;
      }

      function downvote() {
        object.downvotes++;
      }

      function score() {
        let copy = JSON.parse(JSON.stringify(object));
        let allVotes = object.upvotes + object.downvotes;

        if (allVotes > 50) {
          let greaterNum = Math.ceil(
            Math.max(object.upvotes, object.downvotes) * 0.25
          );

          copy.upvotes += greaterNum;
          copy.downvotes += greaterNum;
        }

        copy.balance = object.upvotes - object.downvotes;

        copy.rating =
          allVotes < 10
            ? "new"
            : calcVotePercentage(object.upvotes, allVotes) > 66
            ? "hot"
            : calcVotePercentage(object.downvotes, allVotes) <= 66 &&
              copy.balance >= 0 &&
              (object.upvotes > 100 || object.downvotes > 100)
            ? "controversial"
            : copy.balance < 0
            ? "unpopular"
            : "new";

        return [copy.upvotes, copy.downvotes, copy.balance, copy.rating];
      }

      return eval(action)();
    }
  };
}

let post = {
  id: "3",
  author: "emil",
  content: "wazaaaaa",
  upvotes: 100,
  downvotes: 100
};

let solution = solve();

solution.call(post, "upvote");
solution.call(post, "downvote");
console.log(solution.call(post, "score"));
for (let i = 0; i < 50; i++) {
  solution.call(post, "downvote");
}
console.log(solution.call(post, "score"));
