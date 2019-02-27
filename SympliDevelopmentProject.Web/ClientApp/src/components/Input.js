import React, { PureComponent } from 'react';

class Input extends PureComponent {
    render() {
        const { label, type, options, ...inputProps } = this.props;

        if (type === 'select') {
            return (
                <div className='inputs'>
                    <div className='inputs__label'>{label}</div>
                    <select className='inputs__label__input' {...inputProps}>
                        { options && options.map((opt, index) => <option key={index} value={index}>{opt}</option>) }
                    </select>
                </div>
            );
        }
        return (
            <div className='inputs'>
                <div className='inputs__label'>{label}</div>
                <input {...inputProps} type={type} className='inputs__label__input' />
            </div>
        );
    }
}

export default Input;