/*<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>*/
<script>
    $(document).ready(function() {
        const $sliderContainer = $(".slider-container");
        const $sliderItems = $(".slider-item");
        const interval = 5000; // Change slide every 5 seconds

        let currentIndex = 0;

        function slide() {
            currentIndex = (currentIndex + 1) % $sliderItems.length;
            const translateX = -currentIndex * 100;
            $sliderContainer.css("transform", `translateX(${translateX}%)`);
        }

        setInterval(slide, interval);
    });
</script>
