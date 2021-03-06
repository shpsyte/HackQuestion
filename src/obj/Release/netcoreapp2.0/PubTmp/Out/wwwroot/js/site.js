﻿// Store a reference of the preview video element and a global reference to the recorder instance

var video = document.getElementById('my-preview');
var recorder;

// When the user clicks on start video recording
document.getElementById('btn-start-recording').addEventListener("click", function () {
    // Disable start recording button
    this.disabled = true;

    // Request access to the media devices
    navigator.mediaDevices.getUserMedia({
        audio: true,
        video: true
    }).then(function (stream) {
        // Display a live preview on the video element of the page
        setSrcObject(stream, video);

        // Start to display the preview on the video element
        // and mute the video to disable the echo issue !
        video.play();
        video.muted = true;

        // Initialize the recorder
        recorder = new RecordRTCPromisesHandler(stream, {
            mimeType: 'video/webm',
            bitsPerSecond: 128000
        });

        // Start recording the video
        recorder.startRecording().then(function () {
            console.info('Recording video ...');
        }).catch(function (error) {
            console.error('Cannot start video recording: ', error);
        });

        // release stream on stopRecording
        recorder.stream = stream;

        // Enable stop recording button
        document.getElementById('btn-stop-recording').disabled = false;
    }).catch(function (error) {
        console.error("Cannot access media devices: ", error);
    });
}, false);

function stopVideo() {
    document.getElementById('btn-stop-recording').disabled = true;
    recorder.stopRecording().then(function () {
        console.info('stopRecording success');

        // Retrieve recorded video as blob and display in the preview element
        var videoBlob = recorder.getBlob();
        video.src = URL.createObjectURL(videoBlob);
        video.play();

        // Unmute video on preview
        video.muted = false;

        // Stop the device streaming
        recorder.stream.stop();

        // Enable record button again !
        document.getElementById('btn-start-recording').disabled = false;
    }).catch(function (error) {
        console.error('stopRecording failure', error);
    });
}

// When the user clicks on Stop video recording
document.getElementById('btn-stop-recording').addEventListener("click", function () {
    this.disabled = true;
    stopVideo();
}, false);

$('#record').on('hidden.bs.modal', function (e) {
    stopVideo()
})

