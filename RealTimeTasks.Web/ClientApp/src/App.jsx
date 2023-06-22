import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Routes, Route } from 'react-router-dom';
import PrivateRoute from './PrivateRoute';
import Layout from './Components/Layout';
import { AuthContextComponent } from './AuthContext';
import Home from './pages/Home';
import Signup from './pages/Signup';
import Login from './pages/Login';
import Logout from './pages/Logout';

const App = () => {

    return (
        <AuthContextComponent>
            <Layout>
                <Routes>     
                    <Route path="/" element={
                        <PrivateRoute>
                            <Home />
                        </PrivateRoute>} />
                    <Route exact path='/signup' element={<Signup />} />
                    <Route exact path='/login' element={<Login />} />
                    <Route exact path='/logout' element={<Logout />} />
                </Routes>
            </Layout>
        </AuthContextComponent>
    )

}

export default App;