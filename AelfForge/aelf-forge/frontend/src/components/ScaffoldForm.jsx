import React, { useState } from 'react';
import axios from 'axios';
import { 
    TextField, 
    Button, 
    FormControl, 
    InputLabel, 
    Select, 
    MenuItem, 
    FormHelperText
} from '@mui/material';

function ScaffoldForm({ onGenerate }) {
    const [contractName, setContractName] = useState('');
    const [description, setDescription] = useState('');
    const [template, setTemplate] = useState(''); // Default template

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const response = await axios.post('/api/scaffold', { 
                name: contractName,
                description,
                template
            });

            onGenerate(response.data.code); // Pass generated code to parent
        } catch (error) {
            // Error handling (e.g., display error message to user)
            console.error('Error:', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <TextField 
                label="Contract Name" 
                variant="outlined"
                fullWidth
                margin="normal"
                value={contractName}
                onChange={(e) => setContractName(e.target.value)}
                required
            />

            <TextField
                label="Contract Description"
                variant="outlined"
                fullWidth
                multiline
                rows={4}
                margin="normal"
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                required
            />

            <FormControl fullWidth margin="normal">
                <InputLabel id="template-select-label">Template</InputLabel>
                <Select
                    labelId="template-select-label"
                    id="template-select"
                    value={template}
                    label="Template"
                    onChange={(e) => setTemplate(e.target.value)}
                >
                    <MenuItem value="basic_token">Basic Token</MenuItem>
                    <MenuItem value="nft">NFT</MenuItem>
                    {/* Add more templates as needed */}
                </Select>
                <FormHelperText>Choose a template to start from</FormHelperText>
            </FormControl>

            <Button type="submit" variant="contained" color="primary">
                Generate Contract
            </Button>
        </form>
    );
}

export default ScaffoldForm;
