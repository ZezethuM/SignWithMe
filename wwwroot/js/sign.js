// Dom reference
const curResult = document.querySelector(".cur-result"); // Result output
const scoreContainer = document.querySelector(".score-container"); // score container
const score = document.querySelector(".score"); // score
let playerScore = 0;
let index = 0;

// TM code
// Link to model
const URL = "https://teachablemachine.withgoogle.com/models/5OqxtayUT/";
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

  if (
    prediction[index].className === challenges[index - 1].answer &&
    prediction[index].probability >= 0.95
  ) {
    console.log("yes");
    curResult.innerHTML = `<h2>👌Great</h2>`;
    nextBtn.classList.remove("d-none");
  }
}

const startBtn = document.querySelector(".start-btn");
const challengeContainer = document.querySelector(".challenge-container");
const challenge = document.querySelector(".challenge");
const nextBtn = document.querySelector(".next-btn");

const startChallenge = () => {
  startBtn.classList.add("d-none");
  challengeContainer.classList.remove("d-none");
  nextSign();
  init();
  document.querySelector(".controllers").classList.remove("controllers");
  scoreContainer.classList.remove("d-none");
};
startBtn.addEventListener("click", startChallenge);

// Moving to the next sign
const nextSign = () => {
  // Changing the question image
  challenge.innerHTML = `
  <div class="heading">
  <h4 class="text-center">Alphabet to sign</h4>
  <img src=${challenges[index].image} class="challenge-img" alt="A-Sign" />
  </div>`;
  
  index++;
  nextBtn.classList.add("d-none");
  curResult.innerHTML = `<h2>👉</h2>`;
  score.innerHTML = `${parseInt(score.textContent) + 10}pts`;
};
nextBtn.addEventListener("click", nextSign);

// Challenge questions
const challenges = [
  {
    image: "./images/A_sign.png",
    answer: "A",
  },
  {
    image: "./images/B_sign.jpg",
    answer: "B",
  },
  {
    image: "./images/C_sing.jpg",
    answer: "C",
  },
  {
    image: "./images/D_sign.png",
    answer: "D",
  },
  {
    image: "./images/E_sign.png",
    answer: "E",
  },
];
