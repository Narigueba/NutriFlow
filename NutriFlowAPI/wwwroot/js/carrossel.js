const slidesContainer = document.querySelector('.slides');
const slides = document.querySelectorAll('.slide');
const dots = document.querySelectorAll('.dot');
let current = 0;
const total = slides.length;

function goToSlide(idx) {
  slidesContainer.style.transform = 'translateX(-' + (idx * 100) + '%)';
  dots.forEach(d => d.classList.remove('active'));
  dots[idx].classList.add('active');
  current = idx;
}

dots.forEach(dot => {
  dot.addEventListener('click', () => goToSlide(Number(dot.dataset.index)));
});

setInterval(() => {
  const next = (current + 1) % total;
  goToSlide(next);
}, 5000);
