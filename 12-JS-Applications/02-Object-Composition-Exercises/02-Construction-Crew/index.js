function solve(worker) {
  if (worker.dizziness) {
    let hydration = worker.weight * 0.1 * worker.experience;
    worker.levelOfHydrated += hydration;
    worker.dizziness = false;
  }

  return worker;
}

console.log(
  solve({ weight: 80, experience: 1, levelOfHydrated: 0, dizziness: true })
);
