#pragma once
class EMessage
{
    std::vector<char> data;
public:
    EMessage(const std::vector<char> &data);
    const char* begin(void);
    const char* end(void);
};

