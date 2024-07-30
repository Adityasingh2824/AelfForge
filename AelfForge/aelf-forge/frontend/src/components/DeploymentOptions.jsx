import React, { useState } from 'react';
import {
    Button,
    FormControl,
    InputLabel,
    Select,
    MenuItem,
    TextField,
    FormHelperText,
    Typography,
} from '@mui/material';
import axios from 'axios';
import './DeploymentOptions.css'; 


function DeploymentOptions({ onDeploy, code }) {
    const [network, setNetwork] = useState('testnet'); // Default to testnet
    const [parameters, setParameters] = useState('');
    const [deploymentStatus, setDeploymentStatus] = useState(null); 

    const handleDeployClick = async () => {
        setDeploymentStatus('deploying'); // Update status
        try {
            const response = await axios.post('/api/deploy', {
                code,
                network,
                parameters: parameters.split(',').map(param => param.trim()) // Split and trim parameters
            });

            setDeploymentStatus('success'); // Update status
            onDeploy(response.data); // Call onDeploy with deployment result
        } catch (error) {
            setDeploymentStatus('error'); // Update status
            // Handle deployment error (e.g., show error message)
            console.error('Deployment Error:', error); 
        }
    };

    return (
        <div className="deployment-options">
            <Typography variant="h6" gutterBottom>
                Deployment Options
            </Typography>

            <FormControl fullWidth variant="outlined">
                <InputLabel id="network-select-label">Network</InputLabel>
                <Select
                    labelId="network-select-label"
                    id="network-select"
                    value={network}
                    label="Network"
                    onChange={(e) => setNetwork(e.target.value)}
                >
                    <MenuItem value="testnet">Testnet</MenuItem>
                    <MenuItem value="mainnet">Mainnet</MenuItem>
                </Select>
                <FormHelperText>Choose the network to deploy to.</FormHelperText>
            </FormControl>

            <TextField
                label="Deployment Parameters (comma-separated)"
                variant="outlined"
                fullWidth
                margin="normal"
                value={parameters}
                onChange={(e) => setParameters(e.target.value)}
            />

            {/* Display deployment status */}
            {deploymentStatus === 'deploying' && <Typography>Deploying...</Typography>}
            {deploymentStatus === 'success' && <Typography color="green">Deployment successful!</Typography>}
            {deploymentStatus === 'error' && <Typography color="red">Deployment failed. Check console for details.</Typography>}

            <Button variant="contained" color="primary" onClick={handleDeployClick} disabled={!code}>
                Deploy Contract
            </Button>
        </div>
    );
}

export default DeploymentOptions;
