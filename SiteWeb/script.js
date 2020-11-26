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

$.get("http://localhost:3000/joueurs").then((data) => {
  console.table(data);
  for (let i = 0; i < $(data).length; i++) {
    const table = $(
      `<tr>
        <td>${data[i].pseudo}</td>
        <td>${data[i].score}</td>
        <td>${data[i].score}</td>
      </tr>
      `
    );

    $("table").append(table);
  }
});
