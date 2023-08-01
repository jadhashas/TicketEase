const managementLink = document.getElementById('navbarDropdown');
const dropdownMenu = document.querySelector('.dropdown-menu');

// Track the state of the dropdown menu
let isDropdownOpen = false;

// Function to toggle the dropdown menu
function toggleDropdown() {
    if (isDropdownOpen) {
        // Slide up the dropdown to hide it
        $(dropdownMenu).slideUp(200);
    } else {
        // Slide down the dropdown to show it
        $(dropdownMenu).slideDown(200);
    }
    isDropdownOpen = !isDropdownOpen;
}

// Add click event listener to the management link
managementLink.addEventListener('click', toggleDropdown);

// Add click event listener to the dropdown items to close the dropdown when clicked
const dropdownItems = dropdownMenu.querySelectorAll('.dropdown-item');
dropdownItems.forEach(item => {
    item.addEventListener('click', () => {
        $(dropdownMenu).slideUp(200);
        isDropdownOpen = false;
    });
});