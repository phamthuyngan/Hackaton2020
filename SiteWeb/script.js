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
