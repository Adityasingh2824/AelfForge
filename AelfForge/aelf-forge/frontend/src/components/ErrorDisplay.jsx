import React from 'react';
import { Alert, AlertTitle, List, ListItem, ListItemText, Collapse, IconButton } from '@mui/material';
import CloseIcon from '@mui/icons-material/Close';
import { Error } from '@mui/icons-material';

function ErrorDisplay({ errors }) {
  const [open, setOpen] = React.useState(true);

  const handleClick = () => {
    setOpen(!open);
  };

  return (
    <Collapse in={open}>
      <Alert
        severity="error"
        icon={<Error />}
        action={
          <IconButton
            aria-label="close"
            color="inherit"
            size="small"
            onClick={handleClick}
          >
            <CloseIcon fontSize="inherit" />
          </IconButton>
        }
        sx={{ mb: 2 }}
      >
        <AlertTitle>Errors Found</AlertTitle>
        {errors.length > 0 ? (
          <List>
            {errors.map((error, index) => (
              <ListItem key={index}>
                <ListItemText
                  primary={`Line ${error.line}: ${error.message}`}
                  secondary={error.hint || ""} // Display hint if available
                />
              </ListItem>
            ))}
          </List>
        ) : (
          <Typography>No errors found.</Typography>
        )}
      </Alert>
    </Collapse>
  );
}

export default ErrorDisplay;
