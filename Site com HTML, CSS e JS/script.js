function addTask() {
    const taskInput = document.getElementById('taskInput');
    const taskValue = taskInput.value.trim();

    if (taskValue !== '') {
        const taskTable = document.getElementById('taskTable').getElementsByTagName('tbody')[0];
        const newRow = taskTable.insertRow();
        const newCell = newRow.insertCell(0);
        const newText = document.createTextNode(taskValue);
        newCell.appendChild(newText);

        taskInput.value = '';
    } else {
        alert('Please enter a task.');
    }
}
