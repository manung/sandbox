#!/usr/bin/env ruby
require 'rubygems'
require 'appscript'

include Appscript

yoj = app('Yojimbo')

def output_field(name, field)
    puts name + " " + field.get if field.get != :missing_value
end

def output_fieldarray(name, field)
    puts name + " " + field.get.join(',') if field.get != :missing_value
end

def output_serial(serial)
    output_field("Product Name:", serial.name)
    output_field("Owner Name:", serial.owner_name)
    output_field("Email Address:", serial.email_address)
    output_field("Organization:", serial.organization)
    output_field("Serial Number:", serial.serial_number)
    output_field("Comments:", serial.comments)
    puts
end

def output_item(item, fields)
    values = fields.keys.collect { |key|
        val = item.send(fields[key]).get
        val != :missing_value ? '"' + val + '"': ""
    }
    puts values.join(',')
end

def output_header(fields)
    puts fields.keys.join(',')
end

fields = {
    "Product Name" => :name,
    "Owner Name" => :owner_name,
    "Email Address" => :email_address,
    "Organization" => :organization,
    "Serial Number" => :serial_number
}

output_header(fields)
yoj.serial_number_items.get.each { |x| 
    output_item(x, fields) 
}
