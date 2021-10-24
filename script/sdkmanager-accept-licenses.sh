#!/bin/bash

/usr/bin/expect -c '
set timeout -1;
spawn '"${ANDROID_HOME}"'/tools/bin/sdkmanager --licenses;
  expect {
    "y/N" { exp_send "y\r" ; exp_continue }
    eof
  }
'