import axios from 'axios';

export default axios.create({
  baseURL: 'https://localhost:44398/', //'https://v83jwokeh2.execute-api.us-east-1.amazonaws.com/Prod/api',
  headers: {
    "Content-type": "application/json"
  }
});