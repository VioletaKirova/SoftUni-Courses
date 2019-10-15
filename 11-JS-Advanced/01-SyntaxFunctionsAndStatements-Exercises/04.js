function solve(steps, footprint, speed) {
  let distance = steps * footprint;
  let breaks = Math.floor(distance / 500) * 60;
  let time = distance / (speed / 3.6) + breaks;
  let hours = Math.floor(time / 3600);
  let minutes = Math.floor(time / 60);
  let seconds = Math.round(time % 60);
  hours = hours > 10 ? hours : `0${hours}`;
  minutes = minutes > 10 ? minutes : `0${minutes}`;
  seconds = seconds > 10 ? seconds : `0${seconds}`;
  console.log(`${hours}:${minutes}:${seconds}`);
}

solve(4000, 0.6, 5);
solve(2564, 0.7, 5.5);
