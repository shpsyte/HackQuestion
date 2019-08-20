// Store a reference of the preview video element and a global reference to the recorder instance
function captureCamera(callback) {
  navigator.mediaDevices
    .getUserMedia({ audio: true, video: true })
    .then(function(camera) {
      callback(camera)
    })
    .catch(function(error) {
      alert('Unable to capture your camera. Please check console logs.')
      console.error(error)
    })
}
function stopRecordingCallback() {
  video.src = video.srcObject = null
  video.muted = false
  video.volume = 1
  video.src = URL.createObjectURL(recorder.getBlob())

  recorder.camera.stop()
  recorder.destroy()
  recorder = null
}

var recorder // globally accessible
document.getElementById('btn-start-recording').onclick = function() {
  this.disabled = true
  captureCamera(function(camera) {
    video.muted = true
    video.volume = 0
    video.srcObject = camera
    recorder = RecordRTC(camera, {
      type: 'video'
    })
    recorder.startRecording()
    // release camera on stopRecording
    recorder.camera = camera
    document.getElementById('btn-stop-recording').disabled = false
  })
}
document.getElementById('btn-stop-recording').onclick = function() {
  this.disabled = true
  document.getElementById('btn-start-recording').disabled = false
  recorder.stopRecording(stopRecordingCallback)
}

var video = document.getElementById('my-preview')
var fileExtension = 'webm'
var mimeType = 'video/webm'
var fileExtension = 'webm'
var type = 'video'
var recorderType
var defaultWidth
var defaultHeight
var recorder

function getRandomString() {
  if (
    window.crypto &&
    window.crypto.getRandomValues &&
    navigator.userAgent.indexOf('Safari') === -1
  ) {
    var a = window.crypto.getRandomValues(new Uint32Array(3)),
      token = ''
    for (var i = 0, l = a.length; i < l; i++) {
      token += a[i].toString(36)
    }
    return token
  } else {
    return (Math.random() * new Date().getTime())
      .toString(36)
      .replace(/\./g, '')
  }
}

function getFileName(fileExtension) {
  var d = new Date()
  var year = d.getUTCFullYear()
  var month = d.getUTCMonth()
  var date = d.getUTCDate()
  return (
    'RecordRTC-' +
    year +
    month +
    date +
    '-' +
    getRandomString() +
    '.' +
    fileExtension
  )
}

function stopVideo() {
  document.getElementById('btn-stop-recording').disabled = true
  recorder
    .stopRecording()
    .then(function() {
      console.info('stopRecording success 2')

      // Retrieve recorded video as blob and display in the preview element
      var videoBlob = recorder.getBlob()

      video.src = URL.createObjectURL(videoBlob)

      video.play()

      // // Unmute video on preview
      video.muted = false

      // // Stop the device streaming
      recorder.stream.stop()

      // Enable record button again !
      document.getElementById('btn-start-recording').disabled = false
    })
    .catch(function(error) {
      console.error('stopRecording failure', error)
    })
}

// When the user clicks on Stop video recording
document.getElementById('btn-stop-recording').addEventListener(
  'click',
  function() {
    this.disabled = true
    stopVideo()
  },
  false
)

$('#record').on('hidden.bs.modal', function(e) {
  stopVideo()
})
