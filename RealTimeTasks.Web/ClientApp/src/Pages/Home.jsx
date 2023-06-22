import React, { useState, useEffect, useRef } from 'react';
import { HubConnectionBuilder } from '@microsoft/signalr';
import axios from 'axios';
import { useAuth } from '../AuthContext'

const Home = () => {
    const { user } = useAuth();
    const [taskItems, setTaskItems] = useState([]);
    const [taskTitle, setTaskTitle] = useState('');
    const connectionRef = useRef(null);


    useEffect(() => {
        const connectToHub = async () => {
            const connection = new HubConnectionBuilder().withUrl("/api/task").build();
            await connection.start();
            connectionRef.current = connection;

            connection.on('newTask', t => {
                setTaskItems(taskItems => [...taskItems, t]);
            });

            connection.on('taskUpdate', updatedTasks => {
                setTaskItems(updatedTasks);
            });


        }

        connectToHub();
    }, []);

    useEffect(() => {

        const getTasks = async () => {
            const { data } = await axios.get('/api/task/gettasks');
            setTaskItems(data);
        }
        getTasks();
        console.log(taskItems);
    }, []);


    const onClaimClick = async (task) => {
        console.log(taskItems);
        await axios.post('/api/task/claim', task)
    }

    const onDoneClick = async (task) => {
        await axios.post('/api/task/done', task)
        console.log(taskItems);
    }

    const onAddClick = async () => {
        await axios.post('/api/task/addtask', { title: taskTitle });
        setTaskTitle('');
    }

    return (
        <div>
            <div className="row">
                <div className="col-md-10">
                    <input type="text" className="form-control" placeholder="Task Title" value={taskTitle} onChange={e => setTaskTitle(e.target.value)} />
                </div>
                <div className="col-md-2">
                    <button className="btn btn-primary w-100" onClick={onAddClick}>Add Task</button>
                </div>
            </div>

            <table className="table table-hover table-striped table-bordered mt-3">
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
                    {taskItems.map(task => {
                        return <tr key={task.id}>
                            <td>{task.title}</td>
                            <td>
                                {!task.userId ? <button className="btn btn-dark" onClick={() => onClaimClick(task)}>I'm doing this one!</button>
                                    : task.userId === user.id ? <button className="btn btn-success" onClick={() => onDoneClick(task)}>I'm Done</button>
                                        : <button className="btn btn-warning">{task.user.firstName} {task.user.lastName} is doing this</button>}
                            </td>
                        </tr>
                    })}
                </tbody>
            </table>
        </div>
    );
}

export default Home;