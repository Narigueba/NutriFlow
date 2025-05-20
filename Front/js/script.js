document.addEventListener("DOMContentLoaded", () => {
   
    // Carrossel
    
    const track = document.querySelector('.carousel-track');
    const nextBtn = document.getElementById('next');
    const prevBtn = document.getElementById('prev');
    const carouselItems = document.querySelectorAll('.carousel-item');
    let currentIndex = 0;
  
    if (track && carouselItems.length > 0) {
      const totalItems = carouselItems.length;
  
      function updateCarousel() {
        track.style.transform = `translateX(-${currentIndex * 100}%)`;
      }
  
      if (nextBtn && prevBtn) {
        nextBtn.addEventListener('click', () => {
          currentIndex = (currentIndex + 1) % totalItems;
          updateCarousel();
        });
  
        prevBtn.addEventListener('click', () => {
          currentIndex = (currentIndex - 1 + totalItems) % totalItems;
          updateCarousel();
        });
      }
  
      // Auto-slide carrossel
      setInterval(() => {
        currentIndex = (currentIndex + 1) % totalItems;
        updateCarousel();
      }, 6000);
    }
  
    
    // NavBar
    
    const navButtons = document.querySelectorAll('.bottom-nav button');
  
    if (navButtons.length > 0) {
      navButtons.forEach(button => {
        button.addEventListener('click', () => {
          navButtons.forEach(btn => btn.classList.remove('active'));
          button.classList.add('active');
        });
      });
    }
  });
  