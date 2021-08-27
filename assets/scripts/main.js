const buildUrl = 'Build';
const loaderUrl = buildUrl + '/Build.loader.js';
const config = {
	dataUrl: buildUrl + '/Build.data',
	frameworkUrl: buildUrl + '/Build.framework.js',
	codeUrl: buildUrl + '/Build.wasm',
	streamingAssetsUrl: 'StreamingAssets',
	companyName: 'DefaultCompany',
	productName: 'Sammanslaget',
	productVersion: '1.0',
};

var container = document.querySelector('#unity-container');
// var canvas = document.querySelector('#unity-canvas');
const canvas = document.querySelector('canvas');
var loadingBar = document.querySelector('#unity-loading-bar');
var progressBarFull = document.querySelector('#unity-progress-bar-full');
var fullscreenButton = document.querySelector('#unity-fullscreen-button');
var mobileWarning = document.querySelector('#unity-mobile-warning');

if (/iPhone|iPad|iPod|Android/i.test(navigator.userAgent)) {
	container.className = 'unity-mobile';
	config.devicePixelRatio = 1;
	mobileWarning.style.display = 'block';
	setTimeout(() => {
		mobileWarning.style.display = 'none';
	}, 5000);
	// } else {
	// 	canvas.style.width = '1040px';
	// 	canvas.style.height = '585px';
}
loadingBar.style.display = 'block';

const script = document.createElement('script');
script.src = loaderUrl;
script.onload = () => {
	createUnityInstance(canvas, config, (progress) => {
		progressBarFull.style.width = 100 * progress + '%';
	})
		.then((unityInstance) => {
			loadingBar.style.display = 'none';
			// fullscreenButton.onclick = () => {
			// 	unityInstance.SetFullscreen(1);
			// };
		})
		.catch((message) => {
			alert(message);
		});
};
document.body.appendChild(script);
