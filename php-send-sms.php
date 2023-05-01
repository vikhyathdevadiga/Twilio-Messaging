<?php

$ACCOUNT_SID = "ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
$AUTH_TOKEN = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

$url = "https://api.twilio.com/2010-04-01/Accounts/" .$ACCOUNT_SID. "/Messages.json";
$curl = curl_init($url);
$options = [
    CURLOPT_POST => true,
    CURLOPT_POSTFIELDS => [
        'From' => '+1XXXXXXXXXX',
        'To' => '+11XXXXXXXXXX',
        'Body' => 'Hello'
    ],
    CURLOPT_HTTPHEADER => [
        'Authorization: Basic ' . base64_encode("$ACCOUNT_SID:$AUTH_TOKEN")
    ],
    CURLOPT_RETURNTRANSFER => true
];
curl_setopt_array($curl, $options);
$response = curl_exec($curl);
if (!$response) {
    print curl_error($curl)."\n";
} else {
    print $response;
}
?>