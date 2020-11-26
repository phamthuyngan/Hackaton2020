import "./style.scss";
import $ from "jquery";
// import axios from 'axios';

const buildUrl = "Build";
const loaderUrl = `${buildUrl}/Build.loader.js`;
const config = {
  dataUrl: `${buildUrl}/Build.data.gz`,
  frameworkUrl: `${buildUrl}/Build.framework.js.gz`,
  codeUrl: `${buildUrl}/Build.wasm.gz`,
  streamingAssetsUrl: "StreamingAssets",
  companyName: "DefaultCompany",
  productName: "Hackaton",
  productVersion: "0.1",
};

const container = document.querySelector("#unity-container");
const canvas = document.querySelector("#unity-canvas");
const loadingBar = document.querySelector("#unity-loading-bar");
const progressBarFull = document.querySelector("#unity-progress-bar-full");
const fullscreenButton = document.querySelector("#unity-fullscreen-button");

if (/iPhone|iPad|iPod|Android/i.test(navigator.userAgent)) {
  container.className = "unity-mobile";
  config.devicePixelRatio = 1;
} else {
  canvas.style.width = "960px";
  canvas.style.height = "600px";
}
loadingBar.style.display = "block";

const script = document.createElement("script");
script.src = loaderUrl;
script.onload = () => {
  createUnityInstance(canvas, config, (progress) => {
    progressBarFull.style.width = `${100 * progress}%`;
  })
    .then((unityInstance) => {
      loadingBar.style.display = "none";
      fullscreenButton.onclick = () => {
        unityInstance.SetFullscreen(1);
      };
    })
    .catch((message) => {
      alert(message);
    });
};
document.body.appendChild(script);

// script for the site
// getting info from json file:

$.get("http://localhost:3000/joueurs").then((data) => {
  console.table(data);
  // finding the last player:
  const player = $(
    `<tr><td>${data[data.length - 1].pseudo}</td><td>${
      data[data.length - 1].score
    }</td></tr> `
  );
  $(".player").append(player);

  console.log(data[data.length - 1]);

  // sorting the data by highest score
  function sortResults(prop, asc) {
    data.sort((a, b) => {
      if (asc) {
        return a[prop] > b[prop] ? 1 : a[prop] < b[prop] ? -1 : 0;
      }
      return b[prop] > a[prop] ? 1 : b[prop] < a[prop] ? -1 : 0;
    });
  }
  sortResults("score", false);
  console.table(data);
  // showing the first five places
  for (let i = 0; i < 5; i++) {
    const table = $(
      `<tr>
       <td>${i + 1}</td>
        <td>${data[i].pseudo}</td>
        <td>${data[i].score}</td>
       
      </tr>`
    );

    $(".score").append(table);
  }
});
