// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function openModal() {
    document.getElementById('modal').style.display = 'flex';
}

function closeModal() {
    document.getElementById('modal').style.display = 'none';
}

function showSubtaskInput(id) {
    const form = document.getElementById('form-' + id);
    form.style.display = 'block';
    form.querySelector('input[name="subtask"]').focus();
}

function toggleInfo() {
    const box = document.getElementById('infoBox');
    box.style.display = box.style.display === 'block' ? 'none' : 'block';
}