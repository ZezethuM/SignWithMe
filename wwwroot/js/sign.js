let index = 0;
// Teachable machine

// More API functions here:
// https://github.com/googlecreativelab/teachablemachine-community/tree/master/libraries/image

// the link to your model provided by Teachable Machine export panel
const URL = "https://teachablemachine.withgoogle.com/models/ygzMLw0nd/";

let model, webcam, labelContainer, maxPredictions;

// Load the image model and setup the webcam
async function init() {
  const modelURL = URL + "model.json";
  const metadataURL = URL + "metadata.json";

  // load the model and metadata
  // Refer to tmImage.loadFromFiles() in the API to support files from a file picker
  // or files from your local hard drive
  // Note: the pose library adds "tmImage" object to your window (window.tmImage)
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
  // labelContainer = document.getElementById("label-container");
  // for (let i = 0; i < maxPredictions; i++) {
  //   // and class labels
  //   labelContainer.appendChild(document.createElement("div"));
  // }
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
  
  if (prediction[1].className === challenge[index - 1].answer && prediction[1].probability >= 0.95) {
    console.log("yes")
    document.querySelector(".cur-result").innerHTML = `<h2>👌Great</h2>`;
    nextBtn.classList.remove("d-none");
  }
}

// setTimeout(() => {
//   init();
// }, 1000);

const startBtn = document.querySelector(".start-btn");
const challengeContainer = document.querySelector(".challenge-container");
const nextBtn = document.querySelector(".next-btn");

const startChallenge = () => {
  startBtn.classList.add("d-none");
  challengeContainer.classList.remove("d-none");
  nextSign();
  init();
}
startBtn.addEventListener("click", startChallenge)


const nextSign = () => {
  challengeContainer.innerHTML = `
  <div class="challenge col-3 d-flex justify-content-center">
          <div class="heading">
            <h4 class="text-center">Alphabet to sign</h4>
            <img src=${challenge[index].image} class="challenge-img" alt="A-Sign" />
          </div>
        </div>

        <div  class="col-2 cur-result text-center d-flex flex-column justify-content-center">
          <h2>👉</h2>
        </div>
        
        <div class="answer col-3 d-flex align-items-center flex-column">
          <h4 class="text-center">Sign here</h4>
          <div class="webcover">
            <div id="webcam-container"></div>
          </div>
        </div>`;
    index++;
    nextBtn.classList.add("d-none");
    init();
}
nextBtn.addEventListener("click", nextSign)


const challenge = [
  {
    image: "./images/A_sign.png",
    answer: "A"
  },
  {
    image: "./images/B_sign.jpg",
    answer: "B"
  },
  {
    image: "./images/C_sing.jpg",
    answer: "C"
  },
  {
    image: "./images/D_sign.png",
    answer: "D"
  },
  {
    image: "./images/E_sign.png",
    answer: "E"
  }
]


