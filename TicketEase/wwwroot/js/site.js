const profileDropdownToggle = document.querySelector('.profile-dropdown .dropdown-toggle');
const managementDropdownToggle = document.querySelector('.management-dropdown .dropdown-toggle');
const profileDropdownMenu = document.querySelector('.profile-dropdown .dropdown-menu');
const managementDropdownMenu = document.querySelector('.management-dropdown .dropdown-menu');

// Track the state of the dropdown menus
let isProfileDropdownOpen = false;
let isManagementDropdownOpen = false;

// Function to toggle the profile dropdown menu
function toggleProfileDropdown() {
    if (isProfileDropdownOpen) {
        // Slide up the profile dropdown to hide it
        $(profileDropdownMenu).slideUp(200);
    } else {
        // Slide down the profile dropdown to show it
        $(profileDropdownMenu).slideDown(200);
    }
    isProfileDropdownOpen = !isProfileDropdownOpen;
}

// Function to toggle the management dropdown menu
function toggleManagementDropdown() {
    if (isManagementDropdownOpen) {
        // Slide up the management dropdown to hide it
        $(managementDropdownMenu).slideUp(200);
    } else {
        // Slide down the management dropdown to show it
        $(managementDropdownMenu).slideDown(200);
    }
    isManagementDropdownOpen = !isManagementDropdownOpen;
}

// Add click event listener to the profile dropdown toggle
profileDropdownToggle.addEventListener('click', (e) => {
    toggleProfileDropdown();
    e.stopPropagation(); // Prevent the event from propagating to document
});

// Add click event listener to the management dropdown toggle
managementDropdownToggle.addEventListener('click', (e) => {
    toggleManagementDropdown();
    e.stopPropagation(); // Prevent the event from propagating to document
});

// Add click event listener to the document to close the dropdowns when clicking outside
document.addEventListener('click', () => {
    if (isProfileDropdownOpen) {
        $(profileDropdownMenu).slideUp(200);
        isProfileDropdownOpen = false;
    }
    if (isManagementDropdownOpen) {
        $(managementDropdownMenu).slideUp(200);
        isManagementDropdownOpen = false;
    }
});
