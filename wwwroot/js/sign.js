// Dom reference
const curResult = document.querySelector(".cur-result"); // Result output
const scoreContainer = document.querySelector(".score-container"); // score container
const score = document.querySelector(".score"); // score
const startArrow = document.querySelector(".start-arrow");
const startBtn = document.querySelector(".start-btn");
const challengeContainer = document.querySelector(".challenge-container");
const challenge = document.querySelector(".challenge");
const nextBtn = document.querySelector(".next-btn");
const progressContainer = document.querySelector(".progress-container");
const timer = document.querySelector(".timer");
const body = document.querySelector("body");
const tryBtn = document.querySelector(".try-btn");
const fireworks = document.querySelector(".pyro");
const playBtn = document.querySelector(".play-btn");

// variables
let playerScore = 0;
let index = 0;
let progress = 0;
let challenges = [];

const timeLimit = 15;
let countDown = timeLimit;

let timerInterval;

function theTimer() {
  if (countDown > 0) {
    countDown--;
    console.log(countDown);
    timer.innerHTML = `${countDown}s`;
  } else {
    tryBtn.classList.remove("d-none");
    curResult.innerHTML = `<h2>Time up</h2>`;

    body.classList.remove("bg-white");
    body.classList.remove("bg-success");
    body.classList.add("bg-danger");
  }
}

function stopper() {
  clearInterval(timerInterval);
}

// TM code
// Link to model
const URL = "https://teachablemachine.withgoogle.com/models/6P5I5vzi4/";
let model, webcam, labelContainer, maxPredictions;

// Load the image model and setup the webcam
async function init() {
  const modelURL = URL + "model.json";
  const metadataURL = URL + "metadata.json";

  // TM object to the window
  model = await tmImage.load(modelURL, metadataURL);
  maxPredictions = model.getTotalClasses();

  // Convenience function to setup a webcam
  const flip = true; // whether to flip the webcam
  webcam = new tmImage.Webcam(200, 200, flip); // width, height, flip
  await webcam.setup(); // request access to the webcam
  await webcam.play();
  window.requestAnimationFrame(loop);

  // append elements to the DOM
  document.getElementById("webcam-container").appendChild(webcam.canvas);
}

async function loop() {
  webcam.update(); // update the webcam frame
  await predict();
  window.requestAnimationFrame(loop);
}

// run the webcam image through the image model
async function predict() {
  // predict can take in an image, video or canvas html element
  const prediction = await model.predict(webcam.canvas);

  progress = Math.round(prediction[index].probability * 100);
  progressContainer.innerHTML = `  
    <div class="progress">
      <div class="progress-bar bg-success progress-bar-striped" role="progressbar" style="width: ${progress}%;" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100">${progress}%</div>
    </div>`;

  if (
    prediction[index].className === challenges[index - 1].alphabet &&
    prediction[index].probability >= 0.95
  ) {
    curResult.innerHTML = `<h2>👌Great</h2>`;
    nextBtn.classList.remove("d-none");

    stopper();

    body.classList.remove("bg-white");
    body.classList.remove("bg-danger");
    body.classList.add("bg-success");

    if (index === 5) {
      challengeContainer.classList.add("d-none");
      nextBtn.classList.add("d-none");
      timer.classList.add("d-none");

      body.classList.remove("bg-success");
      fireworks.classList.remove("d-none");
      playBtn.classList.remove("d-none");
    }
  }
}

const startChallenge = async () => {
  await init();

  startBtn.classList.add("d-none");
  startArrow.classList.add("d-none");
  challengeContainer.classList.remove("d-none");
  timer.classList.remove("d-none");

  setTimeout(function () {
    nextSign();
  }, 1000);
};

startBtn.addEventListener("click", startChallenge);

// Moving to the next sign
const nextSign = () => {
  // Changing the question image
  challenge.innerHTML = `
  <div class="heading">
  <h4 class="text-center">Alphabet to sign</h4>
  <img src=${challenges[index].imageFile} class="challenge-img" alt="A-Sign" />
  </div>`;

  progressContainer.innerHTML = `  
    <div class="progress">
      <div class="progress-bar bg-success progress-bar-striped" role="progressbar" style="width: ${
        progress * 100
      }%;" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100">${progress}%</div>
    </div>`;

  index++;
  nextBtn.classList.add("d-none");
  curResult.innerHTML = `<h2>👉</h2>`;
  score.innerHTML = `${parseInt(score.textContent) + 10}pts`;
  body.classList.remove("bg-success");
  body.classList.add("bg-white");

  countDown = timeLimit;
  timer.innerHTML = `${countDown}s`;
  timerInterval = setInterval(theTimer, 1000);
};
nextBtn.addEventListener("click", nextSign);

// Try again function
const trainAgain = () => {
  countDown = 15;

  curResult.innerHTML = `<h2>👉</h2>`;

  tryBtn.classList.add("d-none");
  body.classList.add("bg-white");
  body.classList.remove("bg-danger");
  body.classList.remove("bg-success");
};
tryBtn.addEventListener("click", trainAgain);

function getSigns() {
  axios.get("/api/signs")
    .then(result => challenges = result.data)
    .catch(err => console.log(err))
}

getSigns();

function theChallenges(signs) {
  return signs
}

// Challenge questions
// const challenges = [
//   {
//     image: "./images/A_sign.png",
//     answer: "A",
//   },
//   {
//     image: "./images/B_sign.jpg",
//     answer: "B",
//   },
//   {
//     image: "./images/C_sing.jpg",
//     answer: "C",
//   },
//   {
//     image: "./images/D_sign.png",
//     answer: "D",
//   },
//   {
//     image: "./images/E_sign.png",
//     answer: "E",
//   },
// ];
