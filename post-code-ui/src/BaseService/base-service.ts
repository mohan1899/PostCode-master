import axios from 'axios';

export default axios.create({
  baseURL: 'https://j5utrffkv3.execute-api.us-east-1.amazonaws.com/Prod/api',
  headers: {
    "Content-type": "application/json"
  }
});