import { promise } from './src/promise-of-unity';

promise();

import "./style.scss";
import $ from "jquery";
// import axios from 'axios';


// script for the site
// getting info from json file:

$.get("http://localhost:3000/joueurs").then((data) => {
  console.table(data);
  // finding the last player:
  const player = $(
    `<tr><td>${data[data.length - 1].pseudo}</td><td>${
      data[data.length - 1].score
    }</td></tr> `,
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
       
      </tr>`,
    );

    $(".score").append(table);
  }
});

// Slideshow
let currentSlide = 1;
const slides = document.getElementsByClassName('mySlides');
const dots = document.getElementsByClassName('dot');

function showSlideDot(slideIndex) {
  for (let i = 0; i < slides.length; i++) {
    slides[i].style.display = 'none';
    dots[i].style.color = '#bbb';
  }
  slides[slideIndex - 1].style.display = 'flex';
  dots[slideIndex - 1].style.color = 'rgb(155, 56, 127)';
}

function getCurrentSlide() {
  for (let i = 0; i < dots.length; i++) {
    if (dots[i].style.color === 'rgb(155, 56, 127)') {
      currentSlide = i + 1;
    }
  }
  return currentSlide;
}

function showSlide(slideIndex) {
  if (slideIndex > slides.length) { currentSlide = 1; }
  if (slideIndex < 1) { currentSlide = slides.length; }
  for (let i = 0; i < slides.length; i++) {
    slides[i].style.display = 'none';
    dots[i].style.color = '#bbb';
  }
  slides[currentSlide - 1].style.display = 'flex';
  dots[currentSlide - 1].style.color = 'rgb(155, 56, 127)';
}

function nextSlide() {
  currentSlide = getCurrentSlide();
  showSlide(currentSlide += 1);
}

function previousSlide() {
  currentSlide = getCurrentSlide();
  showSlide(currentSlide -= 1);
}

window.onload = function () {
  showSlide(currentSlide);
  document.getElementById('prev').addEventListener('click', () => {
    previousSlide();
  });
  document.getElementById('next').addEventListener('click', () => {
    nextSlide();
  });
  document.getElementById('dot1').addEventListener('click', () => {
    showSlideDot(1);
  });
  document.getElementById('dot2').addEventListener('click', () => {
    showSlideDot(2);
  });
  document.getElementById('dot3').addEventListener('click', () => {
    showSlideDot(3);
  });
  document.getElementById('dot4').addEventListener('click', () => {
    showSlideDot(4);
  });
  document.getElementById('dot5').addEventListener('click', () => {
    showSlideDot(5);
  });
};
