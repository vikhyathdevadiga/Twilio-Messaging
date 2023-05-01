const axios = require('axios');
const qs = require('qs');

const ACCOUNT_SID = "ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
const AUTH_TOKEN = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

let data = qs.stringify({
  'From': '+1XXXXXXXXXX',
  'To': '+1XXXXXXXXXX',
  'Body': 'Hello' 
});

let config = {
  method: 'post',
  url: `https://api.twilio.com/2010-04-01/Accounts/${ACCOUNT_SID}/Messages.json`,
  headers: { 
    'Content-Type': 'application/x-www-form-urlencoded', 
    'Authorization': 'Basic ' +  Buffer.from(ACCOUNT_SID + ':' + AUTH_TOKEN).toString('base64')
  },
  data : data
};

axios.request(config)
.then((response) => {
  console.log(JSON.stringify(response.data));
})
.catch((error) => {
  console.log(error);
});