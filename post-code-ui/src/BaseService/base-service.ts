import axios from 'axios';
import configData from "../config.json";

export default axios.create({
  baseURL: configData.SERVER_URL,
  headers: {
    "Content-type": "application/json"
  }
});